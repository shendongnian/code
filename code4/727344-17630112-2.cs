    <pre><code>
        &lt;configuration&gt;
        	&lt;configSections&gt;
        		&lt;section name="unity"
                   type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection,
                         Microsoft.Practices.Unity.Configuration, Version=3.0.0.0,
                         Culture=neutral, PublicKeyToken=31bf3856ad364e35" /&gt;
        	&lt;/configSections&gt;
        	&lt;unity&gt;
        		&lt;typeAliases&gt;
        			&lt;typeAlias alias="IMasterInterface"           type="UnityInjection.IMasterInterface, UnityInjection" /&gt;
        			&lt;typeAlias alias="MasterImp"                  type="UnityInjection.MasterImplementation, UnityInjection" /&gt;
        			&lt;typeAlias alias="SatelliteOneImplementation" type="Satellite1.Implementation1, Satellite1" /&gt;
        			&lt;typeAlias alias="SatelliteTwoImplementation" type="Satellite2.Implementation2, Satellite2" /&gt;
        		&lt;/typeAliases&gt;
        		&lt;containers&gt;
        			&lt;container name="containerOne"&gt;
        				&lt;types&gt;
        					&lt;type type="IMasterInterface" mapTo="MasterImp" name="Master" /&gt;
        					&lt;type type="IMasterInterface" mapTo="SatelliteOneImplementation" name="One" /&gt;
        					&lt;type type="IMasterInterface" mapTo="SatelliteTwoImplementation" name="Two" /&gt;
        				&lt;/types&gt;
        			&lt;/container&gt;
        		&lt;/containers&gt;
        	&lt;/unity&gt;
        &lt;/configuration&gt;
    </code></pre>
