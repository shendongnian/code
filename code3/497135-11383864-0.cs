    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NopSolutions.NopCommerce.Nop.DataAccess.MegaProductMenuTableAdapters;
    
    namespace NopSolutions.NopCommerce.BusinessLogic.MegaProductsMenu
    {
        [System.ComponentModel.DataObject]
        public class categoriesBLL
        {
        
            private Nop_CategoryTableAdapter _categoriesAdapter = null;
            protected Nop_CategoryTableAdapter Adapter
            {
                get
                {
                    if (_categoriesAdapter == null)
                        _categoriesAdapter = new Nop_CategoryTableAdapter();
    
                    return _categoriesAdapter;
                }
            }
    
            [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
            public NopCommerce.Nop.DataAccess.MegaProductMenu.Nop_CategoryDataTable GetCategories()
            {
                return Adapter.GetCategories();
            }
    
        }
    
    }
