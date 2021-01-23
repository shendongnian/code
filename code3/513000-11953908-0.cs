    using System;
    using System.Collections.Generic;
    using System.Text;
    using DevExpress.XtraTreeList;
    using System.Windows.Forms;
    using System.Drawing;
    namespace StackOverflowExamples {
    	public class XtraTreeListCellInformation {
    		public void How_To_Get_Geometric_Data_From_XtraTreeList() {
  
    			Form frm = new Form();
    			Label status = new Label() { Dock = DockStyle.Bottom };
    			TreeList list = new TreeList() { Dock = DockStyle.Fill };
  
    			Dictionary<int/*NodeID*/, Rectangle> geometryInfo = new Dictionary<int, Rectangle>();
    			frm.Controls.AddRange( new Control[] { list, status } );
    			list.DataSource = new[] { new { Name = "One" }, new { Name = "Two" }, new { Name = "Three" } };
    			list.CustomDrawNodeCell += ( object sender, CustomDrawNodeCellEventArgs e ) => {
    				if( !geometryInfo.ContainsKey( e.Node.Id ) ) {
    					geometryInfo.Add( e.Node.Id, e.Bounds );
    				} else {
    					geometryInfo[e.Node.Id] = e.Bounds;
  				}
    			};
  
    			list.FocusedNodeChanged += ( object sender, FocusedNodeChangedEventArgs e ) => {
    				status.Text = "Unknown";
    				if( e.Node != null ) {
    					Rectangle rect = Rectangle.Empty;
    					if( geometryInfo.TryGetValue( e.Node.Id, out rect ) ) {
    						status.Text = rect.ToString();
      					} else {
  						status.Text = "Geometry Data Not Ready";
    					}
    				}
    			};
    			frm.ShowDialog();
    		}
    	}
    }
