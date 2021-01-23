    public class Spcart
    {     
     private int _tax = 0;
     public Spcart(int tax)
     {
       _tax = tax;
     }
     public void updatecart(int pid,int qty)
     {
        int amount = qty + _tax;
     }
    }
