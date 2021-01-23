                Num = int.Parse(textBox1.Text);
                if (Num <= 20)
                {
                    if (generate.Length >= Num)
                    {
                        for (int i = Num - 1; i >= 0; i--)
                        {
    
                            name = generate.ElementAt(i);
                            listBox1.Items.Add(name); // Print it to list1 
                            generate = generate.Where(s => s != name).ToArray(); // Delete name after using
                        }
                    }
                    else MessageBox.Show("Sorry, remaining names =" + generate.Length);
                    listBox2.Items.Clear();
                    listBox2.Items.AddRange(generate);
    
                }
                else MessageBox.Show("Max name is 20!");
