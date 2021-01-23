    ﻿<#@ template language="C#" #>
    <##>
    namespace <#= Namespace #>
    {
        public class <#= ClassName #> : IGeneric<<#= TypeParameter #>>
        {
            public <#= TypeParameter #> ReturnResult() => 1 + 3;
        }
    }
    <#+
        public string ClassName { get; set; }
        public string Namespace { get; set; }
        public string TypeParameter { get; set; }
    #>
