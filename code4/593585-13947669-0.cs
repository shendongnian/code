    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
        <configSections>
            <section name="validation" type="Microsoft.Practices.EnterpriseLibrary.Validation.Configuration.ValidationSettings, Microsoft.Practices.EnterpriseLibrary.Validation, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="true" />
        </configSections>
        <validation>
            <type name="ConsoleApplication.Order" defaultRuleset="Validation Ruleset"
                assemblyName="ConsoleApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null">
                <ruleset name="Validation Ruleset">
                    <properties>
                        <property name="BillingEmailAddress">
                            <validator type="Microsoft.Practices.EnterpriseLibrary.Validation.Validators.AndCompositeValidator, Microsoft.Practices.EnterpriseLibrary.Validation, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                                name="And Composite Validator">
                                <validator type="Microsoft.Practices.EnterpriseLibrary.Validation.Validators.OrCompositeValidator, Microsoft.Practices.EnterpriseLibrary.Validation, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                                    name="Or Composite Validator">
                                    <validator type="Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidator, Microsoft.Practices.EnterpriseLibrary.Validation, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                                        negated="true" name="Not Null Validator" />
                                    <validator type="Microsoft.Practices.EnterpriseLibrary.Validation.Validators.StringLengthValidator, Microsoft.Practices.EnterpriseLibrary.Validation, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                                        upperBound="255" lowerBound="5" lowerBoundType="Exclusive"
                                        name="String Length Validator" />
                                </validator>
                                <validator type="Microsoft.Practices.EnterpriseLibrary.Validation.Validators.OrCompositeValidator, Microsoft.Practices.EnterpriseLibrary.Validation, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                                    name="Or Composite Validator 2">
                                    <validator type="Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidator, Microsoft.Practices.EnterpriseLibrary.Validation, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                                        negated="true" name="Not Null Validator" />
                                    <validator type="Microsoft.Practices.EnterpriseLibrary.Validation.Validators.RegexValidator, Microsoft.Practices.EnterpriseLibrary.Validation, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                                        pattern="^[A-Z0-9._%-]+@(?:[A-Z0-9-]+\.)+[A-Z]{2,4}$" options="IgnoreCase"
                                        name="Regular Expression Validator" />
                                </validator>
                            </validator>
                        </property>
                    </properties>
                </ruleset>
            </type>
        </validation>
    </configuration>
