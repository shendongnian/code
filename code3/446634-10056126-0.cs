       public KPage Padre
       {
           get
           {
               if (k_oPagina.father != null)
               {
                   _padre = new KPage((int)k_oPagina.father);
               }
               else
               {
                   _padre = null;
               }
        
               return _padre;
           }
           set { }
       }
    
       private KPage _padre;
