            public double[] Buys { get; set; }
            public void SetBuy(int index, double value)
            {
               if (value > 100)
               {
                  if (Department == "CLOTH")
                   value = value * .95;
                  if (Department == "FOOD")
                   value = value * .90;
                  if (Department == "OTHER")
                   value = value * .97;
               }
               _buys[index] = value;
            }
