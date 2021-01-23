         private void RO_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            String m = RO.SelectedItem.ToString();
            Console.WriteLine(m);
            aCommand2 = new OleDbCommand("select * from branch_tbl,region_tbl where branch_tbl.region_id=region_tbl.region_id and region_tbl.region_name LIKE '" + m + "'", main_connection);
            aAdapter2 = new OleDbDataAdapter(aCommand2);
            ds2 = new DataSet();
            aAdapter2.Fill(ds2, "app_info");
            ds2.Tables[0].Constraints.Add("pk_bno", ds2.Tables[0].Columns[0], true);
            int bran_count = ds2.Tables[0].Rows.Count;
            Console.WriteLine(bran_count);
            checkBox = new CheckBox[bran_count];
            
            for (int i = 0; i < bran_count; ++i)
            {
                checkBox[i] = new CheckBox();
                checkBox[i].Name = "radio" + Convert.ToString(i);
                checkBox[i].Text = ds2.Tables[0].Rows[i][2].ToString();
                checkBox[i].Location = new System.Drawing.Point(125 * i, 15);
                groupBox1.Controls.Add(checkBox[i]);
                checkBox[i].CheckStateChanged += new System.EventHandler(CheckBoxCheckedChanged);
            }
            gpBox=new GroupBox[bran_count];
        }
       String str = null;
       int count = 1;
       int gpcount = 1;
       int position = 1;
       int gpposition = 110;
        //Code for handling event when branch check box is selected or unselected
        private void CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            //Label myLabel;
            String str = null;
            if (c.Checked == true)
            {
                str = c.Text;
                gpBox[gpcount] = new GroupBox();
                gpBox[gpcount].Name = "gpBox" + Convert.ToString(count);
                gpBox[gpcount].Text = str;
                gpBox[gpcount].Location = new Point(5, gpposition);
                gpBox[gpcount].AutoSize = true;
                this.Controls.Add(gpBox[gpcount]);
                
                aCommand3 = new OleDbCommand("select * from batch_tbl where batch_branch LIKE '" + str + "'", main_connection);
                aAdapter3 = new OleDbDataAdapter(aCommand3);
                ds3 = new DataSet();
                aAdapter3.Fill(ds3, "app_info");
                ds3.Tables[0].Constraints.Add("pk_bno", ds3.Tables[0].Columns[0], true);
                int batch_count = ds3.Tables[0].Rows.Count;
                //filling the groupbox with batch code by generating dynamic checkboxes
                for (int i = 0; i < batch_count; ++i)
                {
                    checkBox[i] = new CheckBox();
                    checkBox[i].Name = "check" + Convert.ToString(i);
                    checkBox[i].Text = ds3.Tables[0].Rows[i][1].ToString();
                    Console.WriteLine(checkBox[i].Text);
                    checkBox[i].Location = new System.Drawing.Point(104 * position, 30);
                    gpBox[gpcount].Controls.Add(checkBox[i]);
                    position++;
                    count++;
                }
                position = 1;
                gpposition += 100;
            }
            else
            {
                count--;
                this.Controls.RemoveByKey("lbl" + c.Name);
                this.Update();
            }
        }
