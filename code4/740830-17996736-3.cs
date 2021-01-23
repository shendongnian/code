    Mapper.CreateMap<BusinessEntity, ServiceEntity>()
        .AfterMap((s,d) => {
            var details = s.Details;
            d.FirstName = details.NameFirst;
            d.LastName = details.LastName;
            d.Salary = Int32.Parse(details.Salary);
            var book = details.BookDetails;
            d.BkPrice = book.BookPrice;
            d.BkName = book.BookName;
            d.BkDescription = book.BookDescription;
        })
        .ForAllMembers(m => m.Ignore());
