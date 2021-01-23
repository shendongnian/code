        <sharpRepository>
            <repositories default="ef5Repository">
                <repository name="ef5Repository"
                    connectionString="EfContext"
                    cachingStrategy="standardCachingStrategy"
                    dbContextType="Domain.EfContext, Domain"
                    factory="SharpRepository.Ef5Repository.Ef5ConfigRepositoryFactory, SharpRepository.Ef5Repository"
                />
            </repositories>
        </sharpRepository>
