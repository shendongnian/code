                    Button btn = new Button();
                    btn.Text = "Button text";
                    btn.AutoSize = true;
                    btn.Location = new Point(y, 0);
                    btn.Click += delegate(object sender, EventArgs e)
                    {
                        solution.Invoke(); 
                    }; 
