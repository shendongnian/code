     <asp:Button ID="btn_test" runat="server" OnClick="Button1_Click" Text="Button" />
     protected void Button1_click(Object sender, EventArgs e)
     {
     int ID = 0;
     Label5.Visible = false;
     ID = Convert.ToInt32(GridView1.Rows[row.RowIndex].Cells[1].Text);
     Response.Redirect("~/Producter/Delete?id="+ ID);
     }
