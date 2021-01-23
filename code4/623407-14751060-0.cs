     private void RUN()
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate()
                    {
                        Label l = new Label(); l.Location = new Point(12, 10);
                        l.Text = "Some Text";
                        this.Controls.Add(l);
                    });
                }
                else
                {
                    Label l = new Label();
                    l.Location = new Point(12, 10);
                    l.Text = "Some Text";
                    this.Controls.Add(l);
                }
            }
