    public class FruitTree 
    {
        public string Name { get; set; }
       // your code
       public override string ToString()
       {
           return string.Format("A {0} tree.", Name);
       }
    }
    // later in the click handler
    {
        labelSpecificItem.Text = tree_item.ToString();
    } 
