    <object type="Spring.Objects.Factory.Config.VariablePlaceholderConfigurer, Spring.Core">
          <property name="VariableSources">
            <list>
              <object type="Spring.Objects.Factory.Config.EnvironmentVariableSource, Spring.Core"/>      
              <object type="Spring.Objects.Factory.Config.PropertyFileVariableSource, Spring.Core">
                <property name="Location" value="${root.config}/envars.properties" />
                <property name="IgnoreMissingResources" value="false"/>
              </object>
            </list>
          </property>
        </object>
