            {
                const int Size = 7;
                decimal[] numbers = new decimal[Size];
                decimal total = 0m;
                int index = 0;
                StreamReader inputfile;
                inputfile = File.OpenText("Sales.txt");
                while (index < numbers.Length && !inputfile.EndOfStream)
                {
                    numbers[index] = decimal.Parse(inputfile.ReadLine());
                    index++;
                }
                inputfile.Close();
                foreach (decimal Sales in numbers)
                {
                    outputlistBox1.Items.Add(Sales);
                    total = total + Sales;
                }
                textBox1.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
