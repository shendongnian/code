    <SourceFileList>
      <SourceFile>YourFile.cs</SourceFile>
      <Settings>
        <Analyzers>
          <Analyzer AnalyzerId="Microsoft.StyleCop.CSharp.MaintainabilityRules">
            <Rules>
              <Rule Name="FileMayOnlyContainASingleClass">
                <RuleSettings>
                  <BooleanProperty Name="Enabled">False</BooleanProperty>
                </RuleSettings>
              </Rule>
              <Rule Name="FileMayOnlyContainASingleNamespace">
                <RuleSettings>
                  <BooleanProperty Name="Enabled">False</BooleanProperty>
                </RuleSettings>
              </Rule>
            </Rules>
          </Analyzer>
        </Analyzers>
      </Settings>
    </SourceFileList>
