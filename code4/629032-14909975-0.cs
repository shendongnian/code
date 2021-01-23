        var assembly = typeof(<Type in assembly>).Assembly;
        var types = assembly.GetTypes()
                            .Where(t => String.Equals(
                                t.Namespace,
                                "RepoLib.Rts.Web.Plugins.Profiler.Models",
                                StringComparison.Ordinal))
                            .ToArray();
