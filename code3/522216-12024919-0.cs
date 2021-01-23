    <?xml version="1.0" encoding="utf-8"?>
    <CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
      <CodeSnippet Format="1.0.0">
        <Header>
          <Title>
            New Object
          </Title>
          <Shortcut>someobject</Shortcut>
        </Header>
        <Snippet>
          <Declarations>
            <Literal>
              <ID>InstanceName</ID>
              <ToolTip>Name of the instance</ToolTip>
              <Default>myObject</Default>
              <Type>System.String</Type>
            </Literal>
            <Literal>
              <ID>Name</ID>
              <ToolTip>Name property</ToolTip>
              <Default>Name</Default>
              <Type>System.String</Type>
            </Literal>
    		<Literal>
              <ID>Value</ID>
              <ToolTip>Value property</ToolTip>
              <Default>Value</Default>
              <Type>System.String</Type>
            </Literal>
          </Declarations>
          <Code Language="CSharp">
            <![CDATA[var $InstanceName$ = new MyObject
                {
                    Name = "$Name$",
                    Value = "$Value$"
                };]]>
          </Code>
        </Snippet>
      </CodeSnippet>
    </CodeSnippets>
