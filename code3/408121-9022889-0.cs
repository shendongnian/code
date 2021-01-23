using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace WindowsFormsApplication1 {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
			list.Add( new PurchaseOrderItem() {
				PONumber = 1,
				Description = "First item",
				UM = "something",
				QTY = 2341,
				Cost = 0.99M
			} );
			dataGridView1.DataSource = list;
			dataGridView1.RowsAdded += new DataGridViewRowsAddedEventHandler( dataGridView1_RowsAdded );
		}
		void dataGridView1_RowsAdded( object sender, DataGridViewRowsAddedEventArgs e ) {
			object o = list;	// added for breakpoint with variable viewing
			// you can watch your list changing here, when you add new rows
		}
		BindingList<PurchaseOrderItem> list = new BindingList<PurchaseOrderItem>();
	}
	public class PurchaseOrderItem {
		public Int64 PONumber { get; set; }
		public string Description { get; set; }
		public string UM { get; set; }
		public int QTY { get; set; }
		public decimal Cost { get; set; }
	}
}
