    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsApplication1
    {
        public partial class Form3 : Form
        {
            private List<Node> data;
    
            public Form3()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                InitializeData();
                FillTree();
            }
    
            private void InitializeData()
            {
                 string connString = "Data Source=xxx.xx.xx.xx\\test;Initial Catalog=Test;User id=sa;Password=test;";
                string sql = "USP_RefundRequested";
    
                SqlConnection conn = new SqlConnection(connString);
                data = new List<Node>();
    
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = new SqlCommand(sql, conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
    
                    DataSet ds = new DataSet();
                    da.Fill(ds);
    
                    DataTable dt = ds.Tables[0];
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            ds.Relations.Add("ParentChild",ds.Tables[0].Columns["JID"],
                            ds.Tables[1].Columns["CID"]);
    
                            DataRelation orderRelation = ds.Relations["ParentChild"];
                            foreach (DataRow order in ds.Tables[0].Rows)
                            {
                                //Console.WriteLine("Subtotals for Order {0}:", order["OrderNumber"]);
                                Node parent1 = new Node( order["JID"].ToString(), "", "","","");
    
                                foreach (DataRow oChild in order.GetChildRows(orderRelation))
                                {
                                    //Console.WriteLine("Order Line {0}: {1}", orderDetail["OrderLineNumber"], string.Format("{0:C}", orderDetail["Price"]));
                                    parent1.Children.Add(new Node("", oChild["EntryDate"].ToString(),
                                        oChild["RefundDate"].ToString(),
                                        oChild["ActionBy"].ToString(),
                                        oChild["Comments"].ToString()
                                        ));
                                }
                                data.Add(parent1);
    
                            }
                        }
                    }
    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    conn.Close();
                }
            }
    
            private void FillTree()
            {
    
                this.treeListView1.CanExpandGetter = delegate(object x) { return ((Node)x).Children.Count > 0; };
                this.treeListView1.ChildrenGetter = delegate(object x) { return ((Node)x).Children; };
    
                // create the tree columns and set the delegates to print the desired object proerty
                BrightIdeasSoftware.OLVColumn JIDCol = new BrightIdeasSoftware.OLVColumn("Job ID", "JID");
                JIDCol.AspectGetter = delegate(object x) { return ((Node)x).JID; };
    
                BrightIdeasSoftware.OLVColumn EntryDatecol = new BrightIdeasSoftware.OLVColumn("Entry Date", "EntryDate");
                EntryDatecol.AspectGetter = delegate(object x) { return ((Node)x).EntryDate; };
    
                BrightIdeasSoftware.OLVColumn RefundDatecol = new BrightIdeasSoftware.OLVColumn("Refund Date", "RefundDate");
                RefundDatecol.AspectGetter = delegate(object x) { return ((Node)x).RefundDate; };
    
                BrightIdeasSoftware.OLVColumn ActionBycol2 = new BrightIdeasSoftware.OLVColumn("Action By", "ActionBy");
                ActionBycol2.AspectGetter = delegate(object x) { return ((Node)x).ActionBy; };
    
                BrightIdeasSoftware.OLVColumn Commentscol3 = new BrightIdeasSoftware.OLVColumn("Comments", "Comments");
                Commentscol3.AspectGetter = delegate(object x) { return ((Node)x).Comments; };
    
                // add the columns to the tree
                this.treeListView1.Columns.Add(JIDCol);
                this.treeListView1.Columns.Add(EntryDatecol);
                this.treeListView1.Columns.Add(RefundDatecol);
                this.treeListView1.Columns.Add(ActionBycol2);
                this.treeListView1.Columns.Add(Commentscol3);
                // set the tree roots
                this.treeListView1.Roots = data;
    
                treeListView1.Columns[1].Width = 142;
                treeListView1.Columns[2].Width = 142;
                treeListView1.Columns[3].Width = 179;
                treeListView1.Columns[4].Width = 667;
                treeListView1.Columns[treeListView1.Columns.Count - 1].Width = -2;
    
                treeListView1.ExpandAll();
            }
    
    
        }
    
        public class Node
        {
            public string _jid = "";
            public string JID
            {
                get { return _jid; }
                set { _jid = value; }
            }
    
            //public int _cid = 0;
            //public int CID
            //{
            //    get { return _cid; }
            //    set { _cid = value; }
            //}
    
            public string _entrydate;
            public string EntryDate
            {
                get { return _entrydate; }
                set { _entrydate = value; }
            }
    
    
            public string _refunddate;
            public string RefundDate
            {
                get { return _refunddate; }
                set { _refunddate = value; }
            }
    
    
            public string _actionby = "";
            public string ActionBy
            {
                get { return _actionby; }
                set { _actionby = value; }
            }
    
            public string _comments = "";
            public string Comments
            {
                get { return _comments; }
                set { _comments = value; }
            }
    
            public List<Node> _Children = null;
            public List<Node> Children
            {
                get { return _Children; }
                set { _Children = value; }
            }
    
            public Node(string JID, string EntryDate, string RefundDate, string ActionBy, string Comments)
            {
                this.JID = JID;
                //this.CID = CID;
                this.EntryDate = EntryDate;
                this.RefundDate = RefundDate;
                this.ActionBy = ActionBy;
                this.Comments = Comments;
                this.Children = new List<Node>();
            }
        }
    }
    
    ALTER PROC  USP_RefundRequested  
    AS  
    
    BEGIN  
    ;WITH  Hierarchy AS  
    (  
        SELECT DISTINCT  JID  
                ,CAST(NULL AS DATETIME) EntryDate  
                ,CAST(NULL AS DATETIME) RefundDate  
                ,CAST(NULL AS VARCHAR(MAX)) Comments  
                ,CAST(NULL AS BIT) Refund  
                ,CAST(NULL AS VARCHAR(30)) ActionBy  
                ,nLevel = 1  
       ,0 AS CID  
        FROM refundrequested  
        UNION ALL  
        SELECT   CAST(NULL AS INT) JID  
                ,E.EntryDate  
                ,E.RefundDate  
                ,E.Comments  
                ,E.Refund  
                ,E.ActionBy  
                ,H.nLevel+1  
       ,H.JID  AS CID  
    
        FROM refundrequested   E  
        JOIN Hierarchy  H ON E.JID = H.JID  
    
    )  
    
    --SELECT *  
    --FROM Hierarchy  WHERE CID=0
    --ORDER BY COALESCE(JID, CID) DESC, nLevel  
    
    SELECT * into #tmpHierarchy FROM Hierarchy
    
    SELECT JID,EntryDate,RefundDate,ActionBy,Comments,CID  
    FROM tmpHierarchy  WHERE CID=0
    ORDER BY COALESCE(JID, CID) DESC, nLevel  
    
    SELECT JID,EntryDate,RefundDate,ActionBy,Comments,CID  
    FROM tmpHierarchy  WHERE CID>0
    ORDER BY COALESCE(JID, CID) DESC, nLevel  
    
    drop table #tmpHierarchy
    END  
    go
