                 Detail d = new Detail();
                 d.Foo = "test";
                 list.Add(d);
             }
 
             this.dgv.DataSource = list;
             this.dgv.Columns[0].Visible = false;
             DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
             dgvc.HeaderText = "列标题";
             dgvc.DataPropertyName = "foo";
             this.dgv.Columns.Add(dgvc);
