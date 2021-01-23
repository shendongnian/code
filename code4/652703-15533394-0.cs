     public  void  DoStuff()
    {
         DoPrepWork();
         using( var  controller =  TheMethodYouWroteThatShouldReturnAController())
        {
             DoStuffOverControllerLifetime();
        }
    }
