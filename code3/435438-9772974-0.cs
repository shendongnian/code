       protected override void OnInit( EventArgs e)
        {
            base.OnInit(e);
            int row = 0;
            int count = 0;
            List<string> txtNames = new List<string>();
            txtNames.Add("txtId");
            txtNames.Add("txtName");
            txtNames.Add("txtQty");
            txtNames.Add("txtUnitPrice");
            txtNames.Add("txtExtendedPrice");
            Panel1.Controls.Add(new LiteralControl("\t<tr>\n"));
            TextBox txt;
            foreach (string s in txtNames)
            {
                txt = new TextBox();
                //txt.CopyBaseAttributes(Textbox1);
                txt.BorderWidth = 0;
                txt.ID = s + row;
                Panel1.Controls.Add(new LiteralControl("\t\t<td>"));
                Panel1.Controls.Add(txt);
                Panel1.Controls.Add(new LiteralControl("</td>\n"));
                txt.AutoPostBack = true;
                txt.TextChanged += (sndr, evt) => { Response.Write(((Control)sndr).ID + " --- " + ((TextBox)sndr).Text); };
                if(!IsPostBack)
                    txt.Text = s;
                count++;
            }
            Panel1.Controls.Add(new LiteralControl("\t</tr>\n"));
            row++;
        }
