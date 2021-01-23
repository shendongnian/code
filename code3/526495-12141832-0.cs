    public partial class Form1 : Form
    {
        private string TextFields=string.Empty;
        private string TagFields=string.Empty;
        public Form1()
            {
                InitializeComponent();
            }
    private void Form1_Load(object sender, EventArgs e)
    {
    FillTree();
    }
    
    
    void FillTree()
    {
    DataSet mds = new DataSet();
    DataSet dds = new DataSet();
    string ssql;
    TextFields = "GroupName"; 
    TagFields = "GroupID"; 
    this.treeView1.Nodes.Clear();
    ssql = "select GroupID, GroupName from productgroups ";
    mds =  DB.GetInstance.GetDataSet( ssql);
    if(mds!=null)
       insert1LevelNodes(null,mds.Tables[0]);
    ssql="select ProductID, ProductName, GroupID from products";
    dds =  GetDataSet(ssql);
    if(dds!=null)
    {
    	for(short i = 0;i<this.treeView1.Nodes.Count;i++)
    	{	
    		TextFields = "ProductName";
    		TagFields = "ProductID";
    		insert1LevelNodes(this.treeView1.Nodes[i],dds.Tables[0] );
    
    	}
    }
    dds.Clear();
    dds.Dispose();
    }
    
    
    void insert1LevelNodes(TreeNode parentNode, DataTable dt)
    {
    	string sNodeText = "";
    	string sNodeTag = "";
    	string[] aTexts = this.TextFields.Split(',');
    	string[] aTags = this.TagFields.Split(',');
    	for(int i=0; i< dt.Rows.Count; i++ )
    	{
    		sNodeText = "";
    		sNodeTag = "";
    		for(int k=0;k<dt.Columns.Count;k++)
    		{
    			for(short j=0;j<aTexts.Length;j++)
    				if(aTexts[j].Equals(dt.Columns[k].ColumnName))
    					sNodeText+=dt.Rows[i][k].ToString() + ":";
    			for(short j=0;j<aTags.Length;j++)
    				if(aTags[j].Equals(dt.Columns[k].ColumnName))
    					sNodeTag+=dt.Rows[i][k].ToString() + ",";
    		}
    		if(sNodeText.Length>0) sNodeText = sNodeText.TrimEnd(':');
    		if(sNodeTag.Length>0) sNodeTag = sNodeTag.TrimEnd(',');
    
    		if(sNodeText==string.Empty) return;
    		TreeNode newNode=new TreeNode(sNodeText);
    		newNode.Tag = sNodeTag;
    		if(parentNode==null)
    			treeView1.Nodes.Add(newNode);
    		else
    			parentNode.Nodes.Add(newNode);
    	}
    }
    		
    DataSet GetDataSet(string ssql)
    {
    /// Your function to get Dataset from your Database
    }
    }
