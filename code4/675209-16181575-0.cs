Looking at [AutoMapper's instructions for the QueryableExtensions][1] it has an example showing the Where clause before the projection. You need to refactor your code to support this model, as opposed to placing the Where clause after the projection.
<!-- language: lang-cs -->
public List<OrderLineDTO> GetLinesForOrder(int orderId)
{
  Mapper.CreateMap<OrderLine, OrderLineDTO>()
    .ForMember(dto => dto.Item, conf => conf.MapFrom(ol => ol.Item.Name);
  using (var context = new orderEntities())
  {
    return context.OrderLines.Where(ol => ol.OrderId == orderId)
             .Project().To<OrderLineDTO>().ToList();
  }
}
