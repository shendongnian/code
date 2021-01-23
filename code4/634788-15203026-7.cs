    Public Class ClasificationManagement //application layer service, top layer class
    	Implements IClasificationManagement
    
    	Private _servicio As IClasificacionesService //inject domain serice for bussines
    	Private _repositorio As IClasificationRepository //inject repository for perisitence
    
    	Public Sub New(ByVal servicio As IClasificacionesService, ByVal repositorio As IClasificationRepository)
    		_servicio = servicio
    		_repositorio = repositorio
    	End Sub
    
    	Public sub SwapDescrition(ByVal clasificationOrigenID As String, ByVal clasificationDestinoID As String) Implements IClasificationManagement. SwapDescrition
    
            //code using domain services and repositories
    
    	End sub
    Public class ClasificacionesService
        implements IClasificacionesService
    
      private _tracer as ITracer //inject tracer to service domain
    
      public sub new(tracer as ITracer)
        _tracer =  tracer
      end sub
      
      //not relevant code using ITracer
    
    End Class
