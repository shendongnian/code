                double numPadTotal;
                var IsDouble = double.TryParse(lblPricekey.Text, out numPadTotal);
                if (IsDouble)
                {
                    double finalTotal = total + numPadTotal;
                    txtTotal.Text = finalTotal.ToString();
                }
