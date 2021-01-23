    public List<CompositeDTO> MapToDto(IEnumerable<object> data)
    {
         dtoList = data.Select(Mapper.DynamicMap<CompositeDTO>).ToList();
 
        //foreach (var rec in data) 
        //{
        // dto.InjectFrom(rec );
        // dtoList.Add(dto);
        //}
        return dtoList;
    }
