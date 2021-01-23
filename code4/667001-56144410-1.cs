    ﻿<#@ import namespace="System.IO" #>
    <#@ import namespace="System.Text" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="Microsoft.VisualStudio.TextTemplating" #>
    <#+
        public const string ParametersInjectionPattern = "<" + "#" + "#" + ">";
        public void Generate(string baseTemplatePath, IDictionary<string, string> parameters)
        {
            var template = File.ReadAllText(this.Host.ResolvePath(baseTemplatePath));
            template = template.Replace(ParametersInjectionPattern, GenerateParametersAssignmentControlBlock(parameters));
            this.Write(new Engine().ProcessTemplate(template, this.Host).Trim());
        }
        public string GenerateParametersAssignmentControlBlock(IDictionary<string, string> parameters)
        {
            var sb = new StringBuilder();
            sb.Append('<').Append('#').Append(' ');
        
            foreach (var parameter in parameters)
                sb.Append($"{parameter.Key} = {parameter.Value};");
            sb.Append(' ').Append('#').Append('>');
            return sb.ToString();
        }
        public string SurroundWithQuotes(string str)
        {
            return $"\"{str}\"";
        }
        public string GetTemplateName()
        {
            return Path.GetFileNameWithoutExtension(this.Host.TemplateFile).Replace(".Generated", "");
        }
    #>
