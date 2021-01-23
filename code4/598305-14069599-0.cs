            int countTypeA = 0;
            private void textBox1_KeyUp(object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        ++countTypeA;
                        Console.WriteLine(countTypeA.ToString());
                        break;
                }
            }
