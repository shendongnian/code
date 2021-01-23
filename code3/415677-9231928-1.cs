    var latestChangesetId =
        vcs.QueryHistory(
            "$/",
            VersionSpec.Latest,
            0,
            RecursionType.Full,
            String.Empty,
            VersionSpec.Latest,
            VersionSpec.Latest,
            1,
            false,
            true)
            .Cast<Changeset>()
            .Single()
            .ChangesetId;
