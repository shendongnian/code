    public static OrderDTO ToDto(this Order from)
    {
        return new OrderDTO { 
            Name = from.Name,
            Customer = from.ConvertTo<CustomerDTO>(),
            Items = from.Items.Map(x => x.ConvertTo<ItemDTO>()).ToArray(),
        }
    }
