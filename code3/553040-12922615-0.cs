    using System.CodeDom;
    using System.Web.Compilation;
    using System.Web.UI;
    using Microsoft.WindowsAzure.ServiceRuntime;
    
    public class AzureSettingsExpressionBuilder : ExpressionBuilder
    {
        public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            return new CodePrimitiveExpression(RoleEnvironment.GetConfigurationSettingValue(entry.Expression));
        }
    }
