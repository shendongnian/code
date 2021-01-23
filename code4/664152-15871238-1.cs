    //Add To Your List
                for (DateTime i = moday; i <= sunday; i = i.AddDays(1))
                {
                    comboBox1.Items.Add(i.Date.ToShortDateString());
                }
                //Select Today Date(dd/mm/yyy)
                comboBox1.SelectedItem = DateTime.Today.ToShortDateString();
