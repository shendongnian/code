        protected void Add(object sender, EventArgs e)
        {
            int numOfTxt = Convert.ToInt32(ddlTextBoxes.SelectedItem.Value);
            var table = new Table();
            for (int i = 0; i < numOfTxt; i++)
            {
                var row = new TableRow();
                var cell = new TableCell();
                TextBox textbox = new TextBox();
                textbox.ID = "Textbox" + i;
                textbox.Width = new Unit(180);
                cell.Controls.Add(textbox);
                row.Cells.Add(cell);
                table.Rows.Add(row);
            }
            container.Controls.AddAt(0,table);
            container.Visible = true;
        }
        protected void Submit(object sender, EventArgs e)
        {
            var textboxValues = new List<string>();
            if (Request.Form.HasKeys())
            {
                Request.Form.AllKeys.Where(i => i.Contains("Textbox")).ToList().ForEach(i =>
                    {
                        textboxValues.Add(Request.Form[i]);
                    });
            }
            //Do something with the textbox values
            textboxValues.ForEach(i => Response.Write(i + "<br />"));
            container.Visible = false;
        }
