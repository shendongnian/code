    public class Order
    {
      public string SerialNumber { get; set; }
      public string Description { get; set; }
      public DateTime PostingDate { get; set; }
      public Decimal Amount { get; set; }
      public void SetSerialNumberFromRaw(string serialNumber)
      {
        // Convert to required type, etc.
        this.SerialNumber = <someConvertedValue>;
      }
      public void <OtherNeededValueConverters>
    }    
    List<string> lines = File.ReadAlllines("<filename").ToList();
    List<Order> orders = new List<Order>();
    Order currentOrder = null;
    foreach (string line in lines)
    {
      if (currentOrder = null)
      {
        currentOrder = new Order();
        orders.Add(currentOrder);
        currentOrder.SetSerialNumberFromRaw(line);
      }
      else
      {
        if (line.Contains("DEBIT POS", CultureInfo.CurrentCultureIngoreCase))
        { 
          currentOrder.SetPostingDateAndAmount(line);
          currentOrder = null;
        }
        else
        {
          currentOrder.SetAppendDescription(line);
        }
      }
    }
    
