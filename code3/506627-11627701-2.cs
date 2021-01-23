    using System;
    using System.Collections.Generic;
    _kContext.Products.ToList().ForEach(product => {
        if (product.DiscountRate >= 0.3) {
           product.Price += 10;
        }
    });
