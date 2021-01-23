    var list = new[]
    {
        new { Id = 1, Description = "Red"    },
        new { Id = 1, Description = "Blue"   },
        new { Id = 1, Description = "Green"  },
        new { Id = 2, Description = "Small"  },
        new { Id = 2, Description = "Med"    },
        new { Id = 2, Description = "Large"  },
        new { Id = 3, Description = "Cotton" },
        new { Id = 3, Description = "Silk"   },
    };
    var result = list.GroupBy(t => t.Id).CartesianProduct();
    foreach (var item in result)
    {
        Console.WriteLine(string.Join(" ", item.Select(x => x.Description)));
    }
