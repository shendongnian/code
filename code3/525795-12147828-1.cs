    <unity>
    	<typeAliases>
    <typeAlias alias="IRepositoryInitializer`1" type="Contracts.Repositories.IRepositoryInitializer`1, Contracts" />
    		<typeAlias alias="EFInitializer`2" type="Data.Initializers.EFInitializer`2, Data" />
    </typeAliases>
    	<containers>
    		<container>
    			<types>
    <type type="IRepositoryInitializer`1" mapTo="EFInitializer`2" />
    </types>
    		</container>
    	</containers>
    </unity>
