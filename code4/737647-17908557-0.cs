        private static async Task<Dictionary<string, string>> GetETagsAsync(List<string> feedsLink)
        {
            ValidateFeedsLinkFormat(feedsLink);
            var _eTags = feedsLink.ToDictionary(f => f, f => GetETagAsync(f));
            await TaskEx.WhenAll(_eTags.Values);
            var eTags = _eTags.ToDictionary(k => k.Key, k => k.Value.Result);
            return eTags;
        }
