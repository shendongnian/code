    public static string ReplaceMultiple(this string target, string samples, char replaceWith) {
        if (string.IsNullOrEmpty(target) || string.IsNullOrEmpty(samples))
            return target;
        var tar = target.ToCharArray();
        for (var i = 0; i < tar.Length; i++) {
            for (var j = 0; j < samples.Length; j++) {
                if (tar[i] == samples[j]) {
                    tar[i] = replaceWith;
                    break;
                }
            }
        }
        return new string(tar);
    }
