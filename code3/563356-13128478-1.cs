    <object type="Spring.Objects.Factory.Config.VariablePlaceholderConfigurer, Spring.Core">
       <property name="VariableSources">
          <list>
             <object type="Spring.Objects.Factory.Config.EnvironmentVariableSource, Spring.Core"/>
          </list>
       </property>
    </object>
    
    <object type="MyObject">
      <property name="MyProperty" value="${MyEnvironmentVariableName}"/>
    </object>
