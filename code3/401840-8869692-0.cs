    public static class MappingExtensions
    {
        public static IMappingExpression<Ticket, TDest> MapDetailProperties<TDest>(
             this IMappingExpression<Ticket, TDest> mapBase) where TDest : Detail
        {
            return mapBase
                .ForMember(dest => dest.Priority, 
                    opt => opt.MapFrom(src => src.Priority.Code))
                 ///....
                .ForMember(dest => dest.TeamMembers, 
                   opt => opt.MapFrom(src => src
                       .Schedules.Where(s => s.CompleteTime == null)));
        }
    }
