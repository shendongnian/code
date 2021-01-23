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
    // ReSharper restore InconsistentNaming
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
            return sb;
        }
        private static StringBuilder ParseFilter(ICollection<Filter> groups, GroupOp groupOp) {
            if (groups == null || groups.Count == 0)
                return null;
            var sb = new StringBuilder ();
            bool firstGroup = true;
            foreach (var group in groups) {
                var sbGroup = ParseFilter(group);
                if (sbGroup == null || sbGroup.Capacity == 0)
                    continue;
                if (!firstGroup)
                    // skip groupOp before the first group
                    sb.Append (groupOp);
                else
                    firstGroup = false;
                sb.EnsureCapacity (sb.Length + sbGroup.Length + 2);
                sb.Append ('(');
                sb.Append (sbGroup);
                sb.Append (')');
            }
            return sb;
        }
        public static StringBuilder ParseFilter(Filter filters) {
            var parsedRules = ParseRule (filters.rules, filters.groupOp);
            var parsedGroups = ParseFilter (filters.groups, filters.groupOp);
            if (parsedRules != null && parsedRules.Length > 0) {
                if (parsedGroups != null && parsedGroups.Length > 0) {
                    var sb = new StringBuilder ();
                    sb.Append ('(');
                    sb.Append (parsedRules);
                    sb.Append (')');
                    sb.Append (filters.groupOp);
                    sb.Append ('(');
                    sb.Append (parsedGroups);
                    sb.Append (')');
                    return sb;
                }
                return parsedRules;
            }
            return parsedGroups;
        }
    }
