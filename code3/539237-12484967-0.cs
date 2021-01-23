                                int index = -1;
                                for (int i = 0; i < listBox3.Items.Count; ++i)
                                   if (listBox3.Items[i].Text == Nom2) { ind = i; break; }
                                if (index != -1)
                                {
                                    this.listBox1.Items.Add(t);
                                    MessageBox.Show("Find It");
                                }
                                else { MessageBox.Show("Not Found :@");
