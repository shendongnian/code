    interface IPayPal1{
        void SaleTransaction();
    }
    interface IPayPal2{
        void VoidTransaction();
    }
    class PayPal:IPayPal1, IPayPal2{
        void SaleTransaction(){
            //
        }
        void VoidTransaction(){
            //
        }
    }
    class Service{
        IPayPal1 pp=null;
        static void Main(){
            pp=new PayPal(); //you cannot access VoidTransaction here
        }
    }
