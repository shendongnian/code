    <system.webServer>
        <rewrite>
            <outboundRules>
                <rule name="Cache Bundles" preCondition="IsBundles" patternSyntax="ExactMatch">
                    <match serverVariable="RESPONSE_Vary" pattern="User-Agent" />
                    <action type="Rewrite" value="Accept-Encoding" />
                </rule>
                <preConditions>
                    <preCondition name="IsBundles" patternSyntax="Wildcard">
                        <add input="{URL}" pattern="*/bundles/*" />
                    </preCondition>
                </preConditions>
            </outboundRules>
        </rewrite>
    </system.webServer>
