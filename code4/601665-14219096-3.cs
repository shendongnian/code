    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.UI;
    using FluentValidation;
    namespace stackoverflow.fv
    {
        class Program
        {
            static void Main(string[] args)
            {
                var target = new My() { Id = "1", Name = "" };
                var validator = new MyValidator();
                var result = validator.Validate(target);
                foreach (var error in result.Errors)
                    Console.WriteLine(error.ErrorMessage);
                Console.ReadLine();
            }
        }
        public class MyValidator : AbstractValidator<My>
        {
            public MyValidator()
            {
                RuleFor(x => x.Name).NotEmpty().WithNamedMessage("The name {Name} is not valid for Id {Id}");
            }
        }
        public static class NamedMessageExtensions
        {
            public static IRuleBuilderOptions<T, TProperty> WithNamedMessage<T, TProperty>(
                this IRuleBuilderOptions<T, TProperty> rule, string format)
            {
                return rule.WithMessage("{0}", x => format.JamesFormat(x));
            }
        }
        public class My
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
        public static class JamesFormatter
        {
            public static string JamesFormat(this string format, object source)
            {
                return FormatWith(format, null, source);
            }
            public static string FormatWith(this string format
                , IFormatProvider provider, object source)
            {
                if (format == null)
                    throw new ArgumentNullException("format");
                List<object> values = new List<object>();
                string rewrittenFormat = Regex.Replace(format,
                  @"(?<start>\{)+(?<property>[\w\.\[\]]+)(?<format>:[^}]+)?(?<end>\})+",
                  delegate(Match m)
                  {
                      Group startGroup = m.Groups["start"];
                      Group propertyGroup = m.Groups["property"];
                      Group formatGroup = m.Groups["format"];
                      Group endGroup = m.Groups["end"];
                      values.Add((propertyGroup.Value == "0")
                        ? source
                        : Eval(source, propertyGroup.Value));
                      int openings = startGroup.Captures.Count;
                      int closings = endGroup.Captures.Count;
                      return openings > closings || openings % 2 == 0
                         ? m.Value
                         : new string('{', openings) + (values.Count - 1)
                           + formatGroup.Value
                           + new string('}', closings);
                  },
                  RegexOptions.Compiled
                  | RegexOptions.CultureInvariant
                  | RegexOptions.IgnoreCase);
                return string.Format(provider, rewrittenFormat, values.ToArray());
            }
            private static object Eval(object source, string expression)
            {
                try
                {
                    return DataBinder.Eval(source, expression);
                }
                catch (HttpException e)
                {
                    throw new FormatException(null, e);
                }
            }
        }
    }
