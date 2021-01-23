    List<RadioButton> list = new List<RadioButton>();
                list.Add(radioButton1);
                list.Add(radioButton2);
                list.Add(radioButton3);
                foreach (RadioButton item in list)
                {
                    if(tabControl1.SelectedTab==tabControl1.TabPages[tabControl1.SelectedIndex])
                    item.Checked = false;
                }
