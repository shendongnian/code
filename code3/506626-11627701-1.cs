    using System;
    using System.Collections.Generic;
    GetAll().ToList().ForEach(product => {
        if (product.DiscountRate >= 0.3) {
           product.Price += 10;
        }
    });
