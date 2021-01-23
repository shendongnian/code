    public class NameOfPage
    {
    	protected void btnSubmit_Click(object sender, EventArgs e)
    	{
    		// You could do validation here and display an error message if something is not right.
    		// For simplicity I am assuming the data comes from a set of textboxes.
    		if (!PageIsValid())
    		{
    			return;
    		}
    		
            StockContainer _context = new StockContainer();
            Order newOrder = Order.CreateOrder(txtOrderDate.Text, txtQuantity.Text, txtNeededBy.Text, id);
            _context.Orders.AddObject(newOrder);
            _context.SaveChanges();
    		// Add your redirect logic here.
    	}
    	
    	private bool PageIsValid()
    	{
    		if (string.IsNullOrEmpty(txtOrderDate.Text))
    		{
    			return false;
    		}
    		
    		if (string.IsNullOrEmpty(txtQuantity.Text))
    		{
    			return false;
    		}
    		
    		// and so on for the other fields that are required.
    		return true;
    	}
    } 
