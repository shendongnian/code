    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    namespace RandomWeights
    {
        public class WeightedItem
        {
            public string Text { get; set; }
            public int Weight { get; set; }
    
            public WeightedItem(string text, int weight)
            {
                Text = text; 
                Weight = weight;
            }
        }
        public class WeightedOutput
        {
            public static readonly int _decreaseIncrement = 5;
            List<WeightedItem> items = new System.Collections.Generic.List<WeightedItem>();
    
            public WeightedOutput()
            {
                //initialize the five items with weight = 100
                for (int i = 1; i <= 5; i++)
                    items.Add(new WeightedItem(i.ToString(), 100));
    
                for (int x = 0; x < 50; x++)
                    WriteSelected();
                
                Console.ReadLine();
            }
    
            public void WriteSelected()
            {
                WeightedItem selectedItem = GetItem();
                if (selectedItem != null)
                    Console.WriteLine(selectedItem.Text + ": " + selectedItem.Weight);
                else
                    Console.WriteLine("All items have 0 probability of getting selected");
            }
    
            public WeightedItem GetItem()
            {
                int totalWeight = items.Sum(x=>x.Weight);
                Random rnd = new Random((int)DateTime.Now.Ticks);
                int random = rnd.Next(0, totalWeight);
                
                WeightedItem selected = null;
                foreach (var item in items)
                {
                    if (random < item.Weight && item.Weight > 0)
                    {
                        //need a new item and not a reference to get the right weights
                        selected = new WeightedItem(item.Text, item.Weight);
                        //decrease item's weight
                        item.Weight -= _decreaseIncrement;
                        break;
                    }
    
                    random -= item.Weight;
                }
                return selected;
            }
        }
    }
