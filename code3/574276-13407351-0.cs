    <?xml version="1.0" encoding="utf-8"?>
    <CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
      <CodeSnippet Format="1.0.0">
        <Header>
          <SnippetTypes>
            <SnippetType>Expansion</SnippetType>
          </SnippetTypes>
          <Title>propsession</Title>
          <Author>Lazy</Author>
          <Description>Code snippet for creating property stored in session</Description>
          <HelpUrl></HelpUrl>
          <Shortcut>propsession</Shortcut>
        </Header>
        <Snippet>
          <Declarations>
            <Literal Editable="true">
              <ID>type</ID>
              <ToolTip>Property type</ToolTip>
              <Default>string</Default>
              <Function>
              </Function>
            </Literal>
            <Literal Editable="true">
              <ID>Name</ID>
              <ToolTip>Property name</ToolTip>
              <Default>Name</Default>
              <Function>
              </Function>
            </Literal>
            <Literal Editable="true">
              <ID>name</ID>
              <ToolTip>Key</ToolTip>
              <Default>name</Default>
              <Function>
              </Function>
            </Literal>
          </Declarations>
          <Code Language="csharp"><![CDATA[public static $type$ $Name$
    {
        get
        {
            object obj = HttpContext.Current.Session["$name$"];
    
            if (obj != null)        
                return ($type$)obj;        
    
            return null;
        }
    
        set { HttpContext.Current.Session["$name$"] = value;  }
    }]]></Code>
        </Snippet>
      </CodeSnippet>
    </CodeSnippets>
