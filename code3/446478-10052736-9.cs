    public class Filter {
        public GroupOp groupOp { get; set; }
        public List<Rule> rules { get; set; }
        public List<Filter> groups { get; set; }
    }
    public class Rule {
        public string field { get; set; }
        public Operations op { get; set; }
        public string data { get; set; }
    }
    public enum GroupOp {
        AND,
        OR
    }
    public enum Operations {
        eq, // "equal"
        ne, // "not equal"
        lt, // "less"
        le, // "less or equal"
        gt, // "greater"
        ge, // "greater or equal"
        bw, // "begins with"
        bn, // "does not begin with"
        //in, // "in"
        //ni, // "not in"
        ew, // "ends with"
        en, // "does not end with"
        cn, // "contains"
        nc  // "does not contain"
    }
    public static class WhereClauseGenerator {
        private static readonly string[] FormatMapping = {
            "({0} = '{1}')",               // "eq" - equal
            "({0} <> {1})",                // "ne" - not equal
            "({0} < {1})",                 // "lt" - less than
            "({0} <= {1})",                // "le" - less than or equal to
            "({0} > {1})",                 // "gt" - greater than
            "({0} >= {1})",                // "ge" - greater than or equal to
            "({0} LIKE '{1}%')",           // "bw" - begins with
            "({0} NOT LIKE '{1}%')",       // "bn" - does not begin with
            "({0} LIKE '%{1}')",           // "ew" - ends with
            "({0} NOT LIKE '%{1}')",       // "en" - does not end with
            "({0} LIKE '%{1}%')",          // "cn" - contains
            "({0} NOT LIKE '%{1}%')"       // "nc" - does not contain
        };
        private static StringBuilder ParseRule(ICollection<Rule> rules, GroupOp groupOp) {
            if (rules == null || rules.Count == 0)
                return null;
            var sb = new StringBuilder ();
            bool firstRule = true;
            foreach (var rule in rules) {
                if (!firstRule)
                    // skip groupOp before the first rule
                    sb.Append (groupOp);
                else
                    firstRule = false;
                sb.AppendFormat (FormatMapping[(int)rule.op], rule.field, rule.data);
            }
            return sb.Length > 0 ? sb : null;
        }
        private static void AppendWithBrackets (StringBuilder dest, StringBuilder src) {
            if (src == null || src.Length == 0)
                return;
            if (src.Length > 2 && src[0] != '(' && src[src.Length - 1] != ')') {
                dest.Append ('(');
                dest.Append (src);
                dest.Append (')');
            } else {
                // verify that no other '(' and ')' exist in the b. so that
                // we have no case like src = "(x < 0) OR (y > 0)"
                for (int i = 1; i < src.Length - 1; i++) {
                    if (src[i] == '(' || src[i] == ')') {
                        dest.Append ('(');
                        dest.Append (src);
                        dest.Append (')');
                        return;
                    }
                }
                dest.Append (src);
            }
        }
        private static StringBuilder ParseFilter(ICollection<Filter> groups, GroupOp groupOp) {
            if (groups == null || groups.Count == 0)
                return null;
            var sb = new StringBuilder ();
            bool firstGroup = true;
            foreach (var group in groups) {
                var sbGroup = ParseFilter(group);
                if (sbGroup == null || sbGroup.Length == 0)
                    continue;
                if (!firstGroup)
                    // skip groupOp before the first group
                    sb.Append (groupOp);
                else
                    firstGroup = false;
                sb.EnsureCapacity (sb.Length + sbGroup.Length + 2);
                AppendWithBrackets (sb, sbGroup);
            }
            return sb;
        }
        public static StringBuilder ParseFilter(Filter filters) {
            var parsedRules = ParseRule (filters.rules, filters.groupOp);
            var parsedGroups = ParseFilter (filters.groups, filters.groupOp);
            if (parsedRules != null && parsedRules.Length > 0) {
                if (parsedGroups != null && parsedGroups.Length > 0) {
                    var groupOpStr = filters.groupOp.ToString();
                    var sb = new StringBuilder (parsedRules.Length + parsedGroups.Length + groupOpStr.Length + 4);
                    AppendWithBrackets (sb, parsedRules);
                    sb.Append (groupOpStr);
                    AppendWithBrackets (sb, parsedGroups);
                    return sb;
                }
                return parsedRules;
            }
            return parsedGroups;
        }
    }
