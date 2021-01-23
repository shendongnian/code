    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace frmSales
    {
        public partial class Form1 : Form
        {
            //create object for models
            tblSales modelSales = new tblSales();
            tblSalesLines modelSalesLine = new tblSalesLines();
            View_1 modelView = new View_1();
    
            public Form1()
            {
                InitializeComponent();
                LoadCmbBox();
            }
            
            //Fill dropdown
            private void LoadCmbBox()
            {
                using (DBEntities db = new DBEntities ())
                {
                    var name = from tblProduct in db.tblProduct
                               select tblProduct;
    
                    comboBox1.DataSource = name.ToList();
                    comboBox1.DisplayMember = "barcode";
                }
            }
    
            //txtCName accepts only alphabetical characters
            private void txtCName_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == 8) && !(e.KeyChar == 32))
                {
                    e.Handled = true;
                    MessageBox.Show("This textbox accepts only alphabetical characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //txtPhone accepts only Numbers
            private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8))
                {
                    e.Handled = true;
                    MessageBox.Show("This textbox accepts only Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //txtDec accepts only alphabetical characters
            private void txtDec_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == 8) && !(e.KeyChar == 32))
                {
                    e.Handled = true;
                    MessageBox.Show("This textbox accepts only alphabetical characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //txtQtc accepts only Numbers
            private void txtQtc_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8))
                {
                    e.Handled = true;
                    MessageBox.Show("This textbox accepts only Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //txtUPrice accepts only Numbers
            private void txtUPrice_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8))
                {
                    e.Handled = true;
                    MessageBox.Show("This textbox accepts only Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
    
            private void btnAdd_Click(object sender, EventArgs e)
            {
                //AddButton();
    
                if (txtCName.Text == "")
                {
                    MessageBox.Show("Please Enter Customer Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please Enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtPhone.Text == "")
                {enter code here
                    MessageBox.Show("Please Enter Telephone Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtDec.Text == "")
                {
                    MessageBox.Show("Please Enter Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtQtc.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtUPrice.Text == "")
                {
                    MessageBox.Show("Please Enter Unit Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AddButton();
                    txtDec.Text = txtQtc.Text = txtUPrice.Text = txtTotal.Text = "";
                }
            }
    
            int rCount = 0;
            decimal amount = 0;
            private void AddButton()
            {
                if (txtDec.Text == "")
                {
                    MessageBox.Show("Please Enter Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtQtc.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtUPrice.Text == "")
                {
                    MessageBox.Show("Please Enter Unit Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dataGridView1.Rows.Add();
    
                    rCount++;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = rCount;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = txtDec.Text;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = txtQtc.Text;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = txtUPrice.Text;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value = txtTotal.Text;
    
                    amount = amount + Convert.ToDecimal(txtTotal.Text);
                    txtAmount.Text = Convert.ToString(amount);
                }
    
            }
    
            private void txtUPrice_TextChanged(object sender, EventArgs e)
            {
                txtTotal.Text = "";
                if (txtUPrice.Text != "" && txtQtc.Text != "")
                {
                    double Total = Convert.ToInt32(txtQtc.Text) * Convert.ToDouble(txtUPrice.Text);
                    txtTotal.Text = Convert.ToString(Total);
                }
    
            }
    
            private void txtQtc_TextChanged(object sender, EventArgs e)
            {
                txtTotal.Text = "";
                if (txtUPrice.Text != "" && txtQtc.Text != "")
                {
                    double Total = Convert.ToInt32(txtQtc.Text) * Convert.ToDouble(txtUPrice.Text);
                    txtTotal.Text = Convert.ToString(Total);
                }
            }
            int invoiceNum = 1910020001;
            int invoiceCount = 0001;
            private void btnSave_Click(object sender, EventArgs e)
            {
                
                if (cmbSalesType.Text == "")
                {
                    MessageBox.Show("Please Enter Sales Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    invoiceCount++;
    
                    modelSales.InvNo = invoiceNum + invoiceCount;
                    modelSales.SalesDate = DateTime.Now;
                    modelSales.Amount = Convert.ToInt32(txtAmount.Text);
                    modelSales.CustomerName = txtCName.Text;
                    modelSales.Address = txtAddress.Text;
                    modelSales.Tel = Convert.ToInt32(txtPhone.Text);
                    modelSales.SalesType = cmbSalesType.Text;
    
                    using (DBEntities db = new DBEntities())
                    {
                        db.tblSales.Add(modelSales);
                        db.SaveChanges();
    
    
                        var select = (from tblSales in db.tblSales
                                      select tblSales.SalesID).Max();
    
                        modelSalesLine.SalesID = Convert.ToInt32(select);
    
                        for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
                        {
                            int col = 1;
    
                            modelSalesLine.ProductName = dataGridView1.Rows[rows].Cells[col++].Value.ToString();
                            modelSalesLine.Quantity = Convert.ToInt32(dataGridView1.Rows[rows].Cells[col++].Value.ToString());
                            modelSalesLine.UnitPrice = Convert.ToInt32(dataGridView1.Rows[rows].Cells[col++].Value.ToString());
                            modelSalesLine.Total = Convert.ToInt32(dataGridView1.Rows[rows].Cells[col++].Value.ToString());
    
    
                            db.tblSalesLines.Add(modelSalesLine);
                            db.SaveChanges();
    
                            MessageBox.Show("data saved successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
    
                    }
                }
            }
    
            private void btnViewInvoice_Click(object sender, EventArgs e)
            {
                using (DBEntities db = new DBEntities())
                {
                    DSsales ds = new DSsales();
    
                    //Fil DT Sales
                    var select = (from tblSales in db.tblSales
                                  select tblSales.SalesID).Max();
                    int maxId = Convert.ToInt32(select);
    
                    var result = from tblSalesLines in db.tblSalesLines
                                 where tblSalesLines.SalesID == maxId
                                 select tblSalesLines;
    
                    foreach (var item in result)
                    {
                        var sales = ds.DT_SalesLine.NewDT_SalesLineRow();
    
                        sales[0] = item.SalesLineID;
                        sales[1] = item.SalesID;
                        sales[2] = item.ProductName;
                        sales[3] = item.Quantity;
                        sales[4] = item.UnitPrice;
                        sales[5] = item.Total;
    
                        ds.DT_SalesLine.AddDT_SalesLineRow(sales);
                    }
    
                    //Fil DT SalesLine
                    var result1 = from tblSales in db.tblSales
                                  where tblSales.SalesID == maxId
                                  select tblSales;
    
                    foreach (var item in result1)
                    {
                        var sales = ds.DT_Sales1.NewDT_Sales1Row();
    
                        sales[0] = item.SalesID;
                        sales[1] = item.InvNo;
                        sales[2] = item.SalesDate;
                        sales[3] = item.Amount;
                        sales[4] = item.CustomerName;
                        sales[5] = item.Address;
                        sales[5] = item.Tel;
                        sales[5] = item.SalesType;
    
                        ds.DT_Sales1.AddDT_Sales1Row(sales);
                    }
                    CRSalesReport rpt = new CRSalesReport();
                    rpt.SetDataSource(ds);
    
                    frmCRsales frmCRsales = new frmCRsales();
                    frmCRsales.crystalReportViewer1.ReportSource = rpt;
    
                    frmCRsales.ShowDialog();
                    frmCRsales.Dispose();
                }
            }
    
            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (dataGridView1.CurrentCell.ColumnIndex.Equals(5) && e.RowIndex != -1)
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                comboBox1.Text = "-- Select Barcode --";
            }
    
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                using (DBEntities db = new DBEntities ())
                {
                    try
                    {
                        string barcode = comboBox1.Text;
                        var result2 = db.tblProduct.Where(x => x.barcode == barcode).FirstOrDefault();
                        txtDec.Text = result2.productName;
                    }
                    catch (Exception)
                    {
                        
                    }
                    
                }
                
            }
        }
    }
