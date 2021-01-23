    Friend Class AutomapperMapper
            Implements IMapper
    
            Private _configuration As ConfigurationStore
            Private _mapper As MappingEngine
    
            Public Sub New()
                _configuration = AutoMapper.Mapper.Configuration
                _mapper = AutoMapper.Mapper.Engine
            End Sub
    
            Public Sub New(configuration As ConfigurationStore, mapper As MappingEngine)
                _configuration = configuration
                _mapper = mapper
            End Sub
    
            Public Sub CreateMap(Of TSource, TDestination)() Implements IMapper.CreateMap
                _configuration.CreateMap(Of TSource, TDestination)()
            End Sub
    
            Public Function Map(Of TSource, TDestination)(source As TSource, destination As TDestination) As TDestination Implements IMapper.Map
                Return _mapper.Map(Of TSource, TDestination)(source, destination)
            End Function
    
            Public Function Map(Of TSource, TDestination)(source As TSource) As TDestination Implements IMapper.Map
                Return _mapper.Map(Of TSource, TDestination)(source)
            End Function
    
    
        End Class
