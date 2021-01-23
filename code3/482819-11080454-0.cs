    public static bool IsPageLastVersion(Page page)
        {
            bool isLastVersion = false;
            if (page != null)
            {
                List<VersionedItem> pageVersions = page.GetVersions().ToList();
                pageVersions.Sort((v1, v2) => v1.Version.CompareTo(v2.Version));
                int lastVersion = pageVersions.First().Version;
                isLastVersion = lastVersion == page.Version;
            }
            return isLastVersion;
        }
