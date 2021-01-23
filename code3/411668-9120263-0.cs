    var query = from company in Companies
                join sector in Sectors
                  on company.SectorCode equals sector.SectorCode
                join industry in DistributionSectorIndustry
                  on sector.SectorCode equals industry.SectorCode
                where industry.Service == "numerical"
                select new {
                    company.EquityCusip,
                    company.CompanyName,
                    company.PrimaryExchange,
                    company.SectorCode,
                    sector.Description,
                    industry.IndustryCode
                };
