    <?xml version="1.0" encoding="utf-8" ?>
    <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
    
    	<alias alias="IClasificationManagement" type="AppPrincipal.IClasificationManagement, AppPrincipal" />
    	<alias alias="IClasificationRepository" type="X509ValDAL.IClasificationRepository, X509ValDAL" />
    	<alias alias="IClasificacionesService" type="Entidades.IClasificacionesService, Entidades" />
    	<alias alias="IUnitOfWork" type="X509ValDAL.IUnitOfWork, X509ValDAL" />
    	<alias alias="ObjectContext" type="System.Data.Objects.ObjectContext, System.Data.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
    	<alias alias="ClasificationManagement" type="AppPrincipal.ClasificationManagement, AppPrincipal" />
    	<alias alias="ClasificationRepository" type="X509ValDAL.ClasificationRepository, X509ValDAL" />
    	<alias alias="ClasificacionesService" type="Entidades.ClasificacionesService, Entidades" />
    	<alias alias="UnitOfWork" type="X509ValDAL.UnitOfWork, X509ValDAL" />
    	<alias alias="X509VALEntities" type="Entidades.X509VALEntities, Entidades" />
    	
    
    	<assembly name="AppPrincipal" />
    	<assembly name="X509ValDAL" />
    	<assembly name="Entidades" />
    	<assembly name="System.Data.Entity" />
    
    	<namespace name="AppPrincipal" />
    	<namespace name="X509ValDAL" />
    	<namespace name="Entidades" />
    	<namespace name="System.Data.Objects" />
    	<container>
    	
    		<register type="IClasificationManagement" mapTo="ClasificationManagement">
    			<constructor>
    				<param name="servicio">
    					<dependency/>
    				</param>
    				<param name="repositorio">
    					<dependency/>
    				</param>
    			</constructor>
    		</register>
    	<register type="IClasificationRepository" mapTo="ClasificationRepository">
    			<constructor>
    				<param name="uow">
    					<dependency/>
    				</param>
    			</constructor>
    		</register>
    
    		<register type="IClasificacionesService" mapTo="ClasificacionesService" />
                     TODO: Inject ITracer
    
    		<register type="ObjectContext" mapTo="X509VALEntities" />
    		
    		<register type="IUnitOfWork" mapTo="UnitOfWork" >
    			<constructor>
    				<param name="context">
    					<dependency />
    				</param>
    			</constructor>
    		</register>		
    	
    	</container>
    </unity>
