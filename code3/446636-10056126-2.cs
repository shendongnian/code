       public KPage Padre
       {
           get
           {
               return k_oPagina.father != null
                  ? new KPage((int)k_oPagina.father)
                  : (KPage)null;
           }
       }
