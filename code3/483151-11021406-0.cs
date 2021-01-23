    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FluentNHibernate.Mapping;
    using Eg.Core;
    namespace Eg.FluentMappings.Mappings
    {
        public class ProductMapping : ClassMap<Product>
        {
            public ProductMapping()
            {
                Id(p => p.Id)
                    .GeneratedBy.GuidComb();
                DiscriminateSubClassesOnColumn("ProductType");
                Version(p => p.Version);
                base.NaturalId()
                    .Not.ReadOnly()
                    .Property(parentIsRequired => parentIsRequired.Name);
                Map(p => p.Description);
                Map(p => p.UnitPrice)
                    .Not.Nullable();
            }
        }
    }
